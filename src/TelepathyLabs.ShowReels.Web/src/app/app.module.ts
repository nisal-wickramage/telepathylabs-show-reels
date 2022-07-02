import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowReelListComponent } from './show-reel-list/show-reel-list.component';
import { ShowReelInformationComponent } from './show-reel-information/show-reel-information.component';

@NgModule({
  declarations: [
    AppComponent,
    ShowReelListComponent,
    ShowReelInformationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
