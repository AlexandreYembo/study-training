import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-game-control',
  templateUrl: './game-control.component.html',
  styleUrls: ['./game-control.component.css']
})
export class GameControlComponent implements OnInit {
  @Output() intervalFired = new EventEmitter<number>(); //Making listernable outside.
  interval;
  count: number = 0;
  constructor() { }

  ngOnInit() {
  }


  onStartGame(){
    this.interval = setInterval(() => {
      this.count++;
      this.intervalFired.emit(this.count);
    }, 1000);
  }

  onPauseGame(){
    clearInterval(this.interval);
  }
}
