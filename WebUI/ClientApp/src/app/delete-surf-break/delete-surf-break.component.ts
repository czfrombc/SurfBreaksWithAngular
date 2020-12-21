import { OnInit, Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { ISurfBreak } from "../surf-breaks/surf-break";
import { SurfBreaksService } from "../surf-breaks/surf-breaks.service";

@Component({
  selector: 'delete-surf-break',
  templateUrl: './delete-surf-break.component.html'
})

export class DeleteSurfBreakComponent implements OnInit {

  surfBreak: ISurfBreak = { id: 0, name: "", location: "", break: "" };
  surfBreaks: ISurfBreak[];

  constructor(private surfBreakService: SurfBreaksService, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');
    this.surfBreakService.getSurfBreaks().subscribe(success => {
      if (success) {
        this.surfBreaks = this.surfBreakService.surfBreaks;
        for (var i = 0; i < this.surfBreaks.length; i++) {
          if (this.surfBreaks[i].id == id) {
            this.surfBreak = this.surfBreaks[i];
          }
        }
      }
    });
  }

  onSubmit(form: NgForm) {
    this.surfBreakService.deleteSurfBreak(this.surfBreak).subscribe(
      result => (console.log('success: ', result), this.router.navigate(['surf-breaks-list'])),
      error => console.log('error: ', error)
    );
  }
}
