import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  showTemplate = true;

  ngOnInit() {}

  showContentWrapper() {
    return {
      'content-wrapper': true
    };
  }
}
