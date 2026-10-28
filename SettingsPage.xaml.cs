using System;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace StylishkidsConfections
{
    public partial class SettingsPage : Page
    {
        // Replace with your actual GitHub Owner/Organization and Repository Name
        private const string GitHubOwner = "YOUR_GITHUB_USERNAME";
        private const string GitHubRepo = "YOUR_REPO_NAME";

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Settings successfully updated and saved!", "System Preferences", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async void CheckUpdates_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get current running assembly version
                Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
                string currentVersionStr = $"v{currentVersion.Major}.{currentVersion.Minor}.{currentVersion.Build}";

                // GitHub API URL for the latest release
                string apiUrl = $"https://api.github.com/repos/{GitHubOwner}/{GitHubRepo}/releases/latest";

                using (HttpClient client = new HttpClient())
                {
                    // GitHub API requires a User-Agent header
                    client.DefaultRequestHeaders.Add("User-Agent", "StylishkidsPOS-App");
                    client.Timeout = TimeSpan.FromSeconds(10);

                    string jsonResponse = await client.GetStringAsync(apiUrl);

                    // Parse GitHub's JSON response
                    var releaseInfo = JsonSerializer.Deserialize<GitHubReleaseInfo>(jsonResponse);

                    if (releaseInfo != null && !string.IsNullOrEmpty(releaseInfo.TagName))
                    {
                        // Clean version tag (e.g., strip 'v' if present for comparison)
                        string cleanVersionStr = releaseInfo.TagName.Replace("v", "");
                        Version remoteVersion = new Version(cleanVersionStr);

                        if (remoteVersion > currentVersion)
                        {
                            MessageBoxResult result = MessageBox.Show(
                                $"Release Notes:\n{releaseInfo.Body}\n\nDo you want to open the GitHub release page to download the update?",
                                $"New Update Available ({releaseInfo.TagName})",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question);

                            if (result == MessageBoxResult.Yes)
                            {
                                // Open the GitHub release download page in the default web browser
                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = releaseInfo.HtmlUrl,
                                    UseShellExecute = true
                                });
                            }
                        }
                        else
                        {
                            MessageBox.Show($"You are running the latest version ({currentVersionStr}). No updates available.", "Check for Updates", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not check for updates from GitHub. Please check your internet connection or repository settings.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}