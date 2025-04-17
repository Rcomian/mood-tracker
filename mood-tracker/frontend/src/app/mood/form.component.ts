import { CommonModule } from '@angular/common';
import { Component, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MoodService } from '../core/mood.service';

@Component({
  selector: 'app-mood-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './form.component.html'
})
export class FormComponent {
  @Output() moodAdded = new EventEmitter<void>();

  form: FormGroup;

  constructor(private fb: FormBuilder, private moodService: MoodService) {
    this.form = this.fb.group({
      mood: ['', Validators.required],
      notes: [''],
      date: [new Date().toISOString().slice(0, 10), Validators.required] // ISO date (yyyy-MM-dd)
    });
  }

  submit() {
    if (this.form.invalid) return;

    this.moodService.addMood(this.form.value).subscribe({
      next: () => {
        this.form.reset({date: new Date().toISOString().slice(0, 10) });
        this.moodAdded.emit();
      }
    })
  }
}