topJobs: JobPositionDto[] = [];

ngOnInit() {
  this.jobPositionService.getTopPositions().subscribe(res => {
    this.topJobs = res.items;
  });
}
