import { element } from "protractor";
import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, tap, map } from "rxjs/operators";
import * as groupBy from "lodash/groupBy";

import { IExamResults, ISubjectResults, IResult } from "./examResults";

@Injectable({
  providedIn: "root",
})
export class ExamResultsService {
  // If using Stackblitz, replace the url with this line
  // because Stackblitz can't find the api folder.
  private examResultsApiUrl = "";
  subjectResults: ISubjectResults[];

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.examResultsApiUrl = baseUrl + "api/examresults";
  }

  getResults(): Observable<IExamResults[]> {
    return this.http.get<IExamResults[]>(this.examResultsApiUrl).pipe(
      map((data: IExamResults[]) => data.filter((e) => e.grade == "PASS")),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = "";
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
