import { Component, OnInit } from '@angular/core';
import { AccountsService } from 'src/app/services/accounts.service';

@Component({
  selector: 'app-feedbacks',
  templateUrl: './feedbacks.component.html',
  styleUrls: ['./feedbacks.component.css']
})
export class FeedbacksComponent implements OnInit {
  feedback: any | null;

  constructor(private service: AccountsService) { }

  ngOnInit() {
    this.service.getFeedback().subscribe({
      next: (Data) => {
        this.feedback = Data;
      },
      error: (err) => {
        console.error(err);
      }
    })
  }
}
