import { Time } from "@angular/common";

export interface ITask {
    id: number | null;
    status: string;
    time: Time;
    text: string;
}