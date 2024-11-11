export interface SelectedQuiz {
    topic?:string;
    quizName?:string;
    questions?:QuizQuestions[]
}

export interface QuizQuestions{
    description:string;
    correctAnswer: string;
    answers:string[];
}