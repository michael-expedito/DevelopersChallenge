import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './components/register.component';
import { ListComponent } from './components/list.component';
import { MessageWindowComponent } from './components/message-window/message-window.component';

@NgModule({
  declarations: [
    MessageWindowComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MessageWindowComponent
  ]
})
export class FrameworkModule { }
