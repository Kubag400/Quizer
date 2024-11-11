import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { QuizService } from '../Services/QuizService';
import { Quizz, Quizzes } from '../Interfaces/Quizz';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-full-list',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './full-list.component.html',
  styleUrl: './full-list.component.css'
})
export class FullListComponent implements OnInit {
  @Output() quizSelected = new EventEmitter<string>();
  Clicked(guid: string) {
    this.quizSelected.emit(guid)
  }
  quizzes: Quizzes | null = null;
  constructor(private quizService: QuizService) { }

  ngOnInit(): void {
    this.loadData();
  }
  loadData() {
    this.quizService.loadList().subscribe(result => { this.quizzes = result });
  }
}