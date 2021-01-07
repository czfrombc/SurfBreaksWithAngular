import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

import { ISurfBreak } from "../surf-breaks/surf-break";
import { SurfBreaksService } from "../surf-breaks/surf-breaks.service";

@Component({
  selector: 'surf-breaks-list',
  templateUrl: './surf-breaks-list.component.html',
})

export class SurfBreaksListComponent implements OnInit {

  surfBreaks: ISurfBreak[];
  searchTerm: string; 

  constructor(private surfBreakService: SurfBreaksService, private route: ActivatedRoute) {
  }

  ngDoCheck(): void {
    this.searchTerm = this.route.snapshot.paramMap.get('searchTerm');
    if (this.searchTerm) {
      this.surfBreaks = this.surfBreakService.getSurfBreaksByName(this.searchTerm);
    }
  }

  ngOnInit(): void {
    this.surfBreakService.getSurfBreaks().subscribe(success => {
      if (success) {
        this.surfBreaks = this.surfBreakService.surfBreaks;
      }
    });
  }
}
