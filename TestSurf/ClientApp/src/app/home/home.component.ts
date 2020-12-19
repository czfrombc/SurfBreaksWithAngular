import { Component } from '@angular/core';
import { ISurfBreak } from '../surf-breaks/surf-break';
import { SurfBreaksService } from '../surf-breaks/surf-breaks.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})

export class HomeComponent {

  surfBreaks: ISurfBreak[];

  constructor(private surfBreakService: SurfBreaksService) {
  }

  //ngOnInit(): void {
  //  {
  //    this.surfBreaks = this.surfBreakService.getSurfBreaks();
  //  }
  //}
}
