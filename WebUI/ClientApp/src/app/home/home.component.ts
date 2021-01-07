 import { Component } from '@angular/core';
import { ISurfBreak } from '../surf-breaks/surf-break';
import { SurfBreaksService } from '../surf-breaks/surf-breaks.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})

export class HomeComponent {

  surfBreaks: ISurfBreak[];
  totalCount: number;
  
  constructor(private surfBreakService: SurfBreaksService) {
  }

  ngOnInit(): void {
    this.surfBreakService.getSurfBreaks().subscribe(success => {
      if (success) {
        this.surfBreaks = this.surfBreakService.surfBreaks;
        this.totalCount = this.surfBreaks.length;
      }
    });
  }
}
