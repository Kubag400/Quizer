import { Component, Input } from '@angular/core';
import { Topics } from '../Interfaces/Topic';

@Component({
  selector: 'app-topic-list',
  standalone: true,
  imports: [],
  templateUrl: './topic-list.component.html',
  styleUrl: './topic-list.component.css'
})
export class TopicListComponent {
  // @Input({required:true}) products!:Topics[];
  test:Topics[] = [{
    Topic : "Coding",
    Quizzes: 5
  },
  {
    Topic : "Vet",
    Quizzes: 3
  }];

}


