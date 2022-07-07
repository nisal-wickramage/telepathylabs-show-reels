import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowReelListComponent } from './components/show-reel-list/show-reel-list.component';
import { ShowReelInformationComponent } from './components/show-reel-information/show-reel-information.component';
import { ShowReelEditorComponent } from './components/show-reel-editor/show-reel-editor.component';
import { TimeCodeComponent } from './components/time-code/time-code.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ShowReelListComponent,
    ShowReelInformationComponent,
    ShowReelEditorComponent,
    TimeCodeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
