import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SurfBreaksListComponent } from './surf-breaks-list/surf-breaks-list.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { EditSurfBreakComponent } from './edit-surf-break/edit-surf-break.component';
import { SurfBreakDetailsComponent } from './details/surf-break-details.component';
import { DeleteSurfBreakComponent } from './delete-surf-break/delete-surf-break.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SurfBreaksListComponent,
    SearchBarComponent,
    EditSurfBreakComponent,
    SurfBreakDetailsComponent,
    DeleteSurfBreakComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'surf-breaks-list', component: SurfBreaksListComponent },
      { path: 'edit-surf-break', component: EditSurfBreakComponent },
      { path: 'edit-surf-break/:id', component: EditSurfBreakComponent },
      { path: 'surf-break-details', component: SurfBreakDetailsComponent },
      { path: 'surf-break-details/:id', component: SurfBreakDetailsComponent },
      { path: 'surf-break-details/:id/:saved', component: SurfBreakDetailsComponent },
      { path: 'delete-surf-break', component: DeleteSurfBreakComponent },
      { path: 'delete-surf-break/:id', component: DeleteSurfBreakComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
