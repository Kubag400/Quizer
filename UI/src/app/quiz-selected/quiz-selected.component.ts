import { Component, Input, OnInit } from '@angular/core';
import { QuizQuestions, SelectedQuiz } from '../Interfaces/selected-quiz';
import { QuizDescriptionComponent } from "./quiz-description/quiz-description.component";
import { QuestionComponent } from "./question/question.component";

@Component({
  selector: 'app-quiz-selected',
  standalone: true,
  imports: [QuizDescriptionComponent, QuestionComponent],
  templateUrl: './quiz-selected.component.html',
  styleUrl: './quiz-selected.component.css'
})
export class QuizSelectedComponent{
  @Input({required:true}) selectedQuiz!:SelectedQuiz;  
  max:number = 0;
  points:number = 0
  score:string = "0/0"
  quizStarted:boolean = false;


Started() {
  this.quizStarted = true;
  this.max = this.selectedQuiz.questions!.length
  this.UpdateScore();
}
QuestionAnswerd($event: number) {
  this.points += $event 
  this.UpdateScore();
  }

UpdateScore(){
  this.score = this.points + "/" + this.max; 
}
}
