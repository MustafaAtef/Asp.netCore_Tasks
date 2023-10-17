namespace Configuration_task_one {
    public class SocialMediaLinksOptions {
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Youtube { get; set; }
        public override string ToString() {
            return $"{Facebook}\n{Instagram ?? ""}{(Instagram is not null ? "\n" : "")}{Twitter}\n{Youtube}";
        }
    }
}
