import {Component, DestroyRef, effect, signal} from '@angular/core';
import {ImageService} from '../../services/image.service';
import {interval, startWith} from 'rxjs';
import {switchMap} from 'rxjs/operators';
import {takeUntilDestroyed} from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-counter',
  standalone: true,
  templateUrl: './counter.component.html',
  styleUrl: './counter.component.scss'
})
export class CounterComponent {
  counter = signal(0);

  constructor(private imageService: ImageService, private destroyRef: DestroyRef) {
    effect(() => {
      interval(5000).pipe(
        startWith(0),
        switchMap(() => this.imageService.getLastHourEventsCount()),
        takeUntilDestroyed(this.destroyRef)
      ).subscribe({
        next: (count) => this.counter.set(count),
        error: (err) => console.error('Error: ', err)
      });
    });
  }
}
