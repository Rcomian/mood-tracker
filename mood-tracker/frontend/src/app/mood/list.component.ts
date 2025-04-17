import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MoodService } from '../core/mood.service';
import { MoodEntry } from '../shared/mood-entry';

@Component({
  selector: 'app-mood-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './list.component.html'
})
export class ListComponent implements OnInit {
  moods: MoodEntry[] = [];
  page = 1;
  pageSize = 5;
  totalCount = 0;

  constructor(private moodService: MoodService) {}

  ngOnInit() {
    this.loadMoods();
  }

  loadMoods() {
    this.moodService.getMoods(this.page, this.pageSize).subscribe(res => {
      this.moods = res.data;
      this.totalCount = res.totalCount;
    });
  }

  nextPage() {
    if (this.page * this.pageSize < this.totalCount) {
      this.page++;
      this.loadMoods();
    }
  }

  prevPage() {
    if (this.page > 1) {
      this.page--;
      this.loadMoods();
    }
  }
}
