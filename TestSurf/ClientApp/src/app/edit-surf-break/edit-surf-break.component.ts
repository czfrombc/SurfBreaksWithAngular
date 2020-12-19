import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { ISurfBreak } from "../surf-breaks/surf-break";
import { SurfBreaksService } from "../surf-breaks/surf-breaks.service";

@Component({
  selector: 'edit-surf-break',
  templateUrl: './edit-surf-break.component.html'
})

export class EditSurfBreakComponent implements OnInit {

  surfBreak: ISurfBreak = { id: 0, name: "", location: "", break: "None" };
  message: string = "saved"

  constructor(private surfBreakService: SurfBreaksService, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');
    this.surfBreakService.getSurfBreakById(id).subscribe(
      result => (this.surfBreak = result),
      error => console.log('error: ', error)
    );
  }

  onSubmit(form: NgForm) {
    if (this.surfBreak.id > 0) {
      this.surfBreakService.updateSurfBreak(this.surfBreak).subscribe(
        result => (this.router.navigate(['surf-break-details', this.surfBreak.id, this.message])),
        error => console.log('error: ', error)
      );
    } else {
      this.surfBreakService.createSurfBreak(this.surfBreak).subscribe(
        result => (this.router.navigate(['surf-break-details', result, this.message])),
        error => console.log('error: ', error)
      );
    }
  }
}
