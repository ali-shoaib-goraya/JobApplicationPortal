import { JobApplicationPortalTemplatePage } from './app.po';

describe('JobApplicationPortal App', function () {
    let page: JobApplicationPortalTemplatePage;

    beforeEach(() => {
        page = new JobApplicationPortalTemplatePage();
    });

    it('should display message saying app works', () => {
        page.navigateTo();
        expect(page.getParagraphText()).toEqual('app works!');
    });
});
