import { OnInit, Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

import { ISurfBreak } from "../surf-breaks/surf-break";
import { SurfBreaksService } from "../surf-breaks/surf-breaks.service";

@Component({
  selector: 'surf-break-details',
  templateUrl: './surf-break-details.component.html'
})

export class SurfBreakDetailsComponent implements OnInit {
  surfBreak: ISurfBreak;
  isUpdated: boolean;  // checks to see if saved from the Edit surf break page

  constructor(private surfBreakService: SurfBreaksService, private route: ActivatedRoute) {
  }

  ngOnInit() {

    let id = +this.route.snapshot.paramMap.get('id');
    this.isUpdated = this.route.snapshot.paramMap.get('saved') ? true: false;
    this.surfBreakService.getSurfBreakById(id).subscribe(
      result => (this.surfBreak = result),
      error => console.log('error: ', error)
    );
  }
}
