import { QContainer } from "./qcontainer.model";

export class Theme {
    public constructor(public id: number, public name: string, public qContainer: QContainer[]) {}
}