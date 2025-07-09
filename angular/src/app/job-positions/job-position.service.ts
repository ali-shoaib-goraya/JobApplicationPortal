@Injectable({
  providedIn: 'root'
})
export class JobPositionService {
  baseUrl = '/api/services/app/JobPosition';

  constructor(private http: HttpClient) {}

  getAll(): Observable<JobPositionDto[]> {
    return this.http.get<JobPositionDto[]>(this.baseUrl + '/GetAll');
  }

  create(input: CreateJobPositionDto): Observable<void> {
    return this.http.post<void>(this.baseUrl + '/Create', input);
  }
}
