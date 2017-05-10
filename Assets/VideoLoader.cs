using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour {

	VideoPlayer[] videoPlayers = new VideoPlayer[2];
	int videoIndex = -1;
	// int activeVideoPlayerIndex = 0;
	VideoPlayer activeVideoPlayer;
	Renderer videoRenderer;

	int loadAfterNextFrames;

	void Start () {
		Application.targetFrameRate = 300;
		videoRenderer = this.gameObject.GetComponent<Renderer>();
		for (int i = 0; i < videoPlayers.Length; i++) {
			videoPlayers[i] = AddVideoPlayer();
		}
		loadAfterNextFrames = UnityEngine.Random.Range(150, 300);
		LoadAndPlayNext();
	}
	
	void Update () {
		if (Time.frameCount % loadAfterNextFrames == 0) {
			print("load and play next video...");
			LoadAndPlayNext();
			loadAfterNextFrames = UnityEngine.Random.Range(150, 300);
		}
	}

	VideoPlayer AddVideoPlayer() {
		VideoPlayer player = this.gameObject.AddComponent<VideoPlayer>();
		player.isLooping = true;
		player.playOnAwake = false;
		return player;
	}

	void LoadAndPlayNext() {
		LoadAndPlayVideo(GetNextVideoPlayer(), GetNextVideoUrl());
	}

	void LoadAndPlayVideo(VideoPlayer player, string url) {
		player.url = url;
		player.prepareCompleted += OnVideoPlayerReady;
		// player.errorReceived += OnVideoPlayerError;
		player.Prepare();
	}

	void OnVideoPlayerReady(VideoPlayer player) {
		print("OnVideoPlayerReady");
		player.Play();
		activeVideoPlayer = player;
		videoRenderer.material.mainTexture = player.texture;
		player.prepareCompleted -= OnVideoPlayerReady;
	}

	// void OnVideoPlayerError(VideoPlayer source, string msg) {
	// 	print("video player error: " + msg);
	// }

	VideoPlayer GetNextVideoPlayer() {
		int i;
		for (i = 0; i < videoPlayers.Length; i++) {
			if (videoPlayers[i] == activeVideoPlayer) {
				break;
			}
		}
		int index = (i + 1) % videoPlayers.Length;
		return videoPlayers[index];
	}

	string GetNextVideoUrl() {
		// int index = (videoIndex + 1) % 3;
		// videoIndex = index;

		return GetVideoUrl(UnityEngine.Random.Range(0, 3));
	}

	string GetVideoUrl(int index) {
		// return "file:///Users/kevin/Movies/hypno0" + index + ".m4v";
		return "http://localhost:8080/hypno0" + index + ".m4v";
	}
}
