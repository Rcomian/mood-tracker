export interface MoodEntry {
    id: number;
    mood: string;
    notes?: string;
    date: string;
    userId: number;
  }
  
  export interface PagedResult<T> {
    data: T[];
    page: number;
    pageSize: number;
    totalCount: number;
  }
  