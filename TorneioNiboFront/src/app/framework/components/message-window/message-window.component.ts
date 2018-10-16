import { Message } from './../../models/message.model';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-message-window',
  templateUrl: './message-window.component.html'
})
export class MessageWindowComponent implements OnInit {

  @Input() messages: Message[];

  constructor() { }

  ngOnInit() {
  }

}
