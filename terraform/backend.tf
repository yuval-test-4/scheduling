terraform {
  backend "s3" {
    bucket = "terraform-state-demonstration"
    key    = "development/scheduling"
    region = "us-east-1"
  }
}