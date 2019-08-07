import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-find-family',
  templateUrl: './find-family.component.html',
  styleUrls: ['./find-family.component.css']
})
export class FindFamilyComponent implements OnInit {

  showTable: boolean;
  constructor() { }

  ngOnInit() {
    this.showTable = false;
  }
  btnFindFamilyClicked() {
    this.showTable = true;
  }
}
