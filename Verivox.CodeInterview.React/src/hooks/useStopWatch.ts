import { useState } from "react";

export const useStopWatch = (httpCallback: () => any): [() => Promise<void>, string] => {

    const internalStopWatch = new StopWatch();

    const [stopWatchValue, setStopWatchValue] = useState('');

    const stopWatchHttpWrapper = async () => {
        try {
            internalStopWatch.start();
            await httpCallback();
        } catch (e) {
            throw e;
        } finally {
            internalStopWatch.stop();
            setStopWatchValue(internalStopWatch.format());
        }
    };

    return [stopWatchHttpWrapper, stopWatchValue];
}

class StopWatch {
    private startTime: number = 0;
    private stopTime: number = 0;
    private isRunning: boolean;

    constructor() {
        this.startTime = 0;
        this.stopTime = 0;
        this.isRunning = false;
    }

    start() {
        if (this.isRunning) {
            return;
        }

        this.startTime = new Date().getTime();
        this.isRunning = true;
    }

    stop() {
        if (!this.isRunning) {
            return;
        }

        this.stopTime = new Date().getTime();
        this.isRunning = false;
    }

    reset() {
        this.isRunning = false;
        this.startTime = 0;
        this.startTime = 0;
    }

    format() {
        const duration = this.stopTime - this.startTime;
        const minutes = Math.floor(duration / 60000);
        const seconds = Math.floor((duration % 60000) / 1000);
        const milliseconds = duration % 1000;
        return `${this.padZero(minutes)}:${this.padZero(seconds)}:${this.padZero(milliseconds, 3)}`;
    }

    private padZero(value: number, length = 2): string {
        return value.toString().padStart(length, '0');
    }
}