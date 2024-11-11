import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from "./nav-bar/nav-bar.component";
import { TopicListComponent } from "./topic-list/topic-list.component";
import { FullListComponent } from "./full-list/full-list.component";
import { HttpClient } from '@angular/common/http';
import { QuizSelectedComponent } from "./quiz-selected/quiz-selected.component";
import { SelectedQuiz } from './Interfaces/selected-quiz';
import { QuizService } from './Services/QuizService';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavBarComponent, TopicListComponent, FullListComponent, QuizSelectedComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor(private quizService: QuizService) { }
  title = 'UI';
  quizzSelected: boolean = false;
  selectedQuiz:SelectedQuiz ={
  }

  ShowSelected($event: string) {
    this.quizService.getSelectedQuiz($event).subscribe(result =>{
      this.selectedQuiz.quizName = result.quizName;
      this.selectedQuiz.topic = result.topic;
      this.selectedQuiz.questions = result.questions;
      this.quizzSelected = true;
    });
    }
}
