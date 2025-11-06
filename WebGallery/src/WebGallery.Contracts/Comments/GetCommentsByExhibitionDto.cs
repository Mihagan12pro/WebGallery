namespace WebGallery.Contracts.Comments;
public record GetCommentsByExhibitionDto(Guid exhibitionId, int page, int limit);

