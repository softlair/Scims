import { Scimsver2Page } from './app.po';

describe('scimsver2 App', function() {
  let page: Scimsver2Page;

  beforeEach(() => {
    page = new Scimsver2Page();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
