import { Question } from "./question.model";

export class QContainer {
    public constructor(public id: number, public name: string, public question: Question[]) {}
}