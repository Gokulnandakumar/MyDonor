import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-userinfo-holder',
  templateUrl: './userinfo-holder.component.html',
  styleUrls: ['./userinfo-holder.component.css']
})
export class UserinfoHolderComponent {
  @Input() test: any;
  constructor(){}
}
