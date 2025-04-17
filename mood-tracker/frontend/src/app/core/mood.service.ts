import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { MoodEntry, PagedResult } from '../shared/mood-entry';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class MoodService {
  constructor(private http: HttpClient) {}

  getMoods(page: number = 1, pageSize: number = 10): Observable<PagedResult<MoodEntry>> {
    return this.http.get<PagedResult<MoodEntry>>(
      `${environment.apiUrl}/mood?page=${page}&pageSize=${pageSize}`
    );
  }

  addMood(entry: Partial<MoodEntry>) {
    return this.http.post(`${environment.apiUrl}/mood`, entry);
  }
}
