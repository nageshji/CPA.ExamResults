import { Component, OnInit } from "@angular/core";
import { IExamResults, ISubjectResults, IResult } from "./examResults";
import { ExamResultsService } from "./exam-results.service";
import * as groupBy from "lodash/groupBy";

@Component({
  selector: "app-fetch-data",
  templateUrl: "./exam-results.component.html",
  styleUrls: ["./exam-results.component.css"],
})
export class ExamResultsComponent implements OnInit {
  groupResults$: any[] = [];
  componentTitle = "Exam Results";
  errorMessage = "";

  constructor(private examResultsService: ExamResultsService) {}

  ngOnInit(): void {
    this.examResultsService.getResults().subscribe(
      (response: IExamResults[]) => {
        this.groupResults$ = groupBy(response, "year");
      },
      (error) => {
        console.error(error);
        this.errorMessage =
          "Couldn't load results temporarily, please try again later.";
      }
    );
  }
}
