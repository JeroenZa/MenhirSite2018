import { Component, OnInit } from '@angular/core';
import { TeamClient } from '../api/api.services';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  teamMenuItems: string[]

  constructor(private teamClient: TeamClient) { }

  ngOnInit() {
    this.teamClient.getMenuNames().subscribe(response => {
      this.teamMenuItems = response;
    });
  }
}
