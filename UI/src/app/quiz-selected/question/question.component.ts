import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { QuizQuestions } from '../../Interfaces/selected-quiz';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-question',
  standalone: true,
  imports: [],
  templateUrl: './question.component.html',
  styleUrl: './question.component.css'
})
export class QuestionComponent{
  @Input({required:true}) question!:QuizQuestions;
  @Output() answerd = new EventEmitter<number>();
  result:string = '';
  answerState: 'correct' | 'incorrect' | 'default' = 'default'
  AnswerdQuestion(response: string, correct:string) {
    if(response === correct)
    {
      this.result = "Pass"
      this.answerState = 'correct'
      this.answerd.emit(1);
    }
    else{
      this.answerd.emit(0);
      this.result = "Fail"
      this.answerState = 'incorrect';
    }
  }

  letters:string[] = [
    "A", "B","C","D","E","F","G","H","J","K"
  ]
}
