/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

"use strict";

// Test that highlighters can be configured to automatically hide after a delay.
add_task(async function () {
  info("Loading the test document and opening the inspector");
  const { inspector } = await openInspectorForURL(
    "data:text/html;charset=utf-8,<p id='one'>TEST 1</p>"
  );
  const { waitForHighlighterTypeShown, waitForHighlighterTypeHidden } =
    getHighlighterTestHelpers(inspector);

  const HALF_SECOND = 500;
  const nodeFront = await getNodeFront("#one", inspector);
  const onHighlighterShown = waitForHighlighterTypeShown(
    inspector.highlighters.TYPES.BOXMODEL
  );
  const onHighlighterHidden = waitForHighlighterTypeHidden(
    inspector.highlighters.TYPES.BOXMODEL
  );

  info("Show Box Model Highlighter, then hide after half a second");
  inspector.highlighters.showHighlighterTypeForNode(
    inspector.highlighters.TYPES.BOXMODEL,
    nodeFront,
    { duration: HALF_SECOND }
  );

  info("Wait for Box Model Highlighter shown");
  await onHighlighterShown;
  info("Wait for Box Model Highlighter hidden");
  await onHighlighterHidden;
});
