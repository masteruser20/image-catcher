import {Component, signal, DestroyRef, OnInit} from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ImageService } from '../services/image.service';
import {DatePipe, NgIf} from '@angular/common';
import { ImageResponse } from '../interfaces/responses/image.response';
import { CounterComponent } from '../components/counter/counter.component';
import {takeUntilDestroyed} from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [MatCardModule, MatProgressSpinnerModule, NgIf, CounterComponent, DatePipe],
  providers: [ImageService],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  currentImage = signal<ImageResponse | null>(null);
  isFetching = signal(true);

  constructor(
    private imageService: ImageService,
    private destroyRef: DestroyRef
  ) {}

  ngOnInit() {
    this.setupImagePolling();
  }

  private setupImagePolling() {
    this.imageService.pollImages().pipe(
      takeUntilDestroyed(this.destroyRef)
    ).subscribe({
      next: (image: ImageResponse | null) => {
        if (image) {
          this.currentImage.set(image);
        }
        this.isFetching.set(false);
      }
    });
  }
}
