
constructor(private dialogService: DialogService) {}

openCreateDialog() {
  const ref = this.dialogService.open(CreateEditJobPositionComponent, {
    header: 'Create Job Position',
    width: '500px',
    data: { isEdit: false }
  });

  ref.onClose.subscribe(() => this.loadJobPositions());
}
