import { QOption } from "./qoption.model";

export class Question {
    public constructor(public id: number, public question: string, public level: string, public answer: string,
                       public qOption: QOption) {}
}