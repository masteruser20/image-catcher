import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ImageResponse} from '../interfaces/responses/image.response';
import {catchError, Observable, of} from 'rxjs';
import {switchMap, timer} from 'rxjs';

@Injectable()
export class ImageService {
  private readonly FETCH_INTERVAL = 5000;

  constructor(private httpService: HttpClient, @Inject('API_URL') private apiUrl: string) {
  }

  getLastImage(): Observable<ImageResponse> {
    return this.httpService.get<ImageResponse>(`${this.apiUrl}/ImageCatcher`);
  }

  getLastHourEventsCount(): Observable<number> {
    return this.httpService.get<number>(`${this.apiUrl}/ImageCatcher/LastEventsCount`);
  }

  pollImages(): Observable<ImageResponse | null> {
    return timer(0, this.FETCH_INTERVAL).pipe(
      switchMap(() => this.getLastImage().pipe(
        catchError((error) => {
          console.error('Error when fetching an image:', error);
          return of(null);
        })
      ))
    );
  }
}
