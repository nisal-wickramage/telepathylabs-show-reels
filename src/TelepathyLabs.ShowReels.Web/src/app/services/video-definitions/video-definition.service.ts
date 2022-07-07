import { Injectable } from '@angular/core';
import config from '../../../assets/config.json';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { KeyValuePair } from '../models/key-value-pair';

@Injectable({
  providedIn: 'root'
})
export class VideoDefinitionService {
  private showReelsApiUrl: string = config.ShowReelsApiUrl;
  
  constructor(private httpClient: HttpClient) { 
  }
  
  get(): Observable<KeyValuePair[]> {
    return this.httpClient.get<KeyValuePair[]>(`${this.showReelsApiUrl}videodefinition`);
  }
}
