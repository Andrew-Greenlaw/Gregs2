export class House {
  constructor(data) {
    this.Id = data.Id
    this.CreatorId = data.CreatorId
    this.Creator = data.Creator
    this.CreatedAt = data.CreatedAt
    this.UpdatedAt = data.UpdatedAt
    this.Bedrooms = data.Bedrooms
    this.Bathrooms = data.Bathrooms
    this.Levels = data.Levels
    this.ImgUrl = data.ImgUrl
    this.Price = data.Price
    this.Description = data.Description
    this.IsSold = data.IsSold
    this.FavoriteId = data.FavoriteId
  }
}