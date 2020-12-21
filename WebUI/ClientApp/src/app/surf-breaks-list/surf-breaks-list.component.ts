import { Component, OnInit } from "@angular/core";

import { ISurfBreak } from "../surf-breaks/surf-break";
import { SurfBreaksService } from "../surf-breaks/surf-breaks.service";

@Component({
  selector: 'surf-breaks-list',
  templateUrl: './surf-breaks-list.component.html',
})

export class SurfBreaksListComponent implements OnInit {

  surfBreaks: ISurfBreak[];

  constructor(private surfBreakService: SurfBreaksService) {
  }

  ngOnInit(): void {
    this.surfBreakService.getSurfBreaks().subscribe(success => {
      if (success) {
        this.surfBreaks = this.surfBreakService.surfBreaks;
      }
    });
  }
}
