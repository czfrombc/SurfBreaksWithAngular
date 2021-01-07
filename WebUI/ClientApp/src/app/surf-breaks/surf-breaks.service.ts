import { Injectable, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable, of } from "rxjs";
import { map } from "rxjs/operators";

import { ISurfBreak } from "./surf-break";
import { ISurfBreakTransferObject } from "./surf-break-transfer-object";

@Injectable({
  providedIn: 'root'
})

export class SurfBreaksService {

  public surfBreak: ISurfBreak;
  public surfBreaks: ISurfBreak[];
  public sbto: ISurfBreakTransferObject = new ISurfBreakTransferObject();  //created to transfer the BreakType from string to C# enum int
  private surfBreaksUrl: string = "api/surfBreaks";


  constructor(private http: HttpClient) { }

  getSurfBreaks() {

    return this.http.get("api/surfBreaks").pipe(
      map((data: any[]) => {
        this.surfBreaks = data;
        for (var i = 0; i < this.surfBreaks.length; i++) {
          this.surfBreaks[i].break = this.getBreakTypes(Number(this.surfBreaks[i].break));
        }
        return true;
      }))
  }

  getSurfBreakById(id: number): Observable<any> {
    return this.http.get(this.surfBreaksUrl + "/" + id).pipe(
      map((data: any) => {
        this.surfBreak = data;
        this.surfBreak.break = this.getBreakTypes(Number(this.surfBreak.break));
        return this.surfBreak;
      }));
  }

  getSurfBreaksByName(searchTerm: string): ISurfBreak[] {
    var filtered = this.surfBreaks.filter(surfBreak => surfBreak.name.startsWith(searchTerm.substring(0,1).toUpperCase() + searchTerm.substring(1)));
    return filtered;
  }

  getSurfBreaksCount(): number {
    return this.surfBreaks.length;
  }

  createSurfBreak(surfBreak: ISurfBreak): Observable<any> {
    this.sbto = this.getSurfBreakTransferObject(surfBreak);
    return this.http.post(this.surfBreaksUrl + "/" + this.sbto.id, this.sbto);
  }

  updateSurfBreak(surfBreak: ISurfBreak): Observable<any> {
    this.sbto = this.getSurfBreakTransferObject(surfBreak);
    return this.http.put(this.surfBreaksUrl + "/" + this.sbto.id, this.sbto);
  }

  deleteSurfBreak(surfBreak: ISurfBreak): Observable<any> {
    return this.http.delete(this.surfBreaksUrl + "/" + surfBreak.id);
  }

  // converts BreakType property from C# enum int to string
  getBreakTypes(id: number): string {
    let breakType;
    switch (id) {
      case 0:
        breakType = "None";
        break;
      case 1:
        breakType = "Beach";
        break;
      case 2:
        breakType = "Point";
        break;
      case 3:
        breakType = "Reef";
        break;
      default:
        breakType = "None";
        break;
    }
    return breakType;
  }

  // Converts BreakType property from string to C# enum int
  setBreakTypeToNumber(id: string): number {
    let breakType = 0;
    switch (id) {
      case "None":
        breakType = 0;
        break;
      case "Beach":
        breakType = 1;
        break;
      case "Point":
        breakType = 2;
        break;
      case "Reef":
        breakType = 3;
        break;
      default:
        breakType = 0;
        break;
    }
    return breakType;
  }

  // Converts surf break to a transfer object so properties can convert to C# enum
  getSurfBreakTransferObject(surfBreak: ISurfBreak): ISurfBreakTransferObject {
    this.sbto.id = surfBreak.id;
    this.sbto.name = surfBreak.name;
    this.sbto.location = surfBreak.location;
    this.sbto.break = this.setBreakTypeToNumber(surfBreak.break);
    return this.sbto;
  }
}
