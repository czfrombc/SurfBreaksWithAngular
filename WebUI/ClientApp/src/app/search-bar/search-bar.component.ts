import { Component } from "@angular/core";
import { Router } from "@angular/router";

import { SurfBreaksService } from "../surf-breaks/surf-breaks.service";

@Component({
  selector: 'search-bar',
  templateUrl: './search-bar.component.html'
})

export class SearchBarComponent {
  input: string = "";

  constructor(private surfBreakService: SurfBreaksService,  private router: Router) {
  }

  performSearch(searchTerm: HTMLInputElement): void {
    console.log(`User entered: ${searchTerm.value}`);
    this.input = searchTerm.value;

    this.surfBreakService.getSurfBreaks().subscribe(
      result => (this.router.navigate(['surf-breaks-list', this.input])),
      error => console.log('error: ', error)
    );
  }
}
