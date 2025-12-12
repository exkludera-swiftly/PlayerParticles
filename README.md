<div align="center">
	<img width="600" height="131" alt="logo" src="https://github.com/user-attachments/assets/f718e40b-4717-4f66-8963-7ebf92cbd024" />
	<h3><strong>Player Particles</strong></h3>
	<h4>a plugin that creates particles for players</h4>
	<h2>
		<img src="https://img.shields.io/github/downloads/exkludera-swiftly/PlayerParticles/total" alt="Downloads">
		<img src="https://img.shields.io/github/stars/exkludera-swiftly/PlayerParticles?style=flat&logo=github" alt="Stars">
		<img src="https://img.shields.io/github/forks/exkludera-swiftly/PlayerParticles?style=flat&logo=github" alt="Forks">
		<img src="https://img.shields.io/github/license/exkludera-swiftly/PlayerParticles" alt="License">
	</h2>
	<!--<a href="https://discord.gg" target="_blank"><img src="https://img.shields.io/badge/Discord%20Server-7289da?style=for-the-badge&logo=discord&logoColor=white" /></a> <br>-->
	<a href="https://ko-fi.com/exkludera" target="_blank"><img src="https://img.shields.io/badge/KoFi-af00bf?style=for-the-badge&logo=kofi&logoColor=white" alt="Buy Me a Coffee at ko-fi.com" /></a>
	<a href="https://paypal.com/donate/?hosted_button_id=6AWPNVF5TLUC8" target="_blank"><img src="https://img.shields.io/badge/PayPal-0095ff?style=for-the-badge&logo=paypal&logoColor=white" alt="PayPal"  /></a>
	<a href="https://github.com/sponsors/exkludera" target="_blank"><img src="https://img.shields.io/badge/Sponsor-696969?style=for-the-badge&logo=github&logoColor=white" alt="GitHub Sponsor" /></a>
</div>

## Requirements
- [SwiftlyS2](https://swiftlys2.net/)
- [MultiAddonManager](https://github.com/Source2ZE/MultiAddonManager) (optional for custom particles)

## Showcase
<details>
	<summary>content</summary>
	<img width="200" height="250" alt="image" src="https://github.com/user-attachments/assets/de25c61b-d360-493a-ae5a-3ac6c3cd3257" />
	<img width="200" height="250" alt="image" src="https://github.com/user-attachments/assets/1c704900-baa5-472f-b720-62a250ca6e0e" />
	<img width="200" height="250" alt="image" src="https://github.com/user-attachments/assets/a84e0666-8cb0-4c35-9d51-58a23d8dbe17" />

[workshop files](https://files.catbox.moe/bjlwyo.zip)

</details>

## Config
<details>
<summary>config.jsonc</summary>
  
```json
{
  "PlayerParticles": {
    "Groups":
    [
      {
        "Permissions": [""],
        "Team": "both",
        "Particles": ["particles/therazu/other/roles/player.vpcf"]
      },
      {
        "Permissions": ["vip"],
        "Team": "both",
        "Particles": ["particles/therazu/other/roles/vip.vpcf"]
      },
      {
        "Permissions": ["admin"],
        "Team": "both",
        "Particles": ["particles/therazu/other/roles/admin.vpcf"]
      }
    ]
  }
}
```
</details>
