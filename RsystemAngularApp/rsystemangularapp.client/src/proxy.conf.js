const PROXY_CONFIG = [
  {
    context: [
      "/api/Stories",
    ],
    target: "http://localhost:5237",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
