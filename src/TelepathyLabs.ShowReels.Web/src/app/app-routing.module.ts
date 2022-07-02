import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowReelEditorComponent } from './show-reel-editor/show-reel-editor.component';
import { ShowReelListComponent } from './show-reel-list/show-reel-list.component';

const routes: Routes = [
  { path: 'new-show-reel', component: ShowReelEditorComponent},
  { path: '**', component: ShowReelListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
