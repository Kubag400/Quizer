import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Quizz, Quizzes } from "../Interfaces/Quizz";
import { SelectedQuiz } from "../Interfaces/selected-quiz";

@Injectable({
    providedIn:'root'
})
export class QuizService{

    private baseUrl = 'http://localhost:19570';
    private getAllUrl = '/Quiz/GetQuizzes'
    private getQuizWithDetails = '/Quiz/GetQuizWithDetails?quizId='

constructor(private httpClient: HttpClient){}

    loadList(){
        return this.httpClient.get<Quizzes>(this.baseUrl + this.getAllUrl)
    }

    getSelectedQuiz(id:string){
        return this.httpClient.get<SelectedQuiz>(this.baseUrl  + this.getQuizWithDetails + id);
    }
}