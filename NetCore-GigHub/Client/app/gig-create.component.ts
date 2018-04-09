import { Component } from '@angular/core';

@Component({
  selector: 'gig-create',
  templateUrl: "./gig-create.component.html",
  styles: []
})
export class GigCreateComponent {

  model: any = {
    Venue: String,
    Date: String,
    Time: String,
    Genre: String
  }

  createGig(formValues) {
    console.dir(formValues);
  }

  genres = [
    { id: "id1", title: "Genre1" },
    { id: "id2", title: "Genre2" },
    { id: "id3", title: "Genre3" },
    { id: "id4", title: "Genre4" },
    { id: "id5", title: "Genre5" },
    { id: "id6", title: "Genre6" },
    { id: "id7", title: "Genre7" },
    { id: "id8", title: "Genre8" }
  ]
}
